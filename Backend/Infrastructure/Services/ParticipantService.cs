﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Halko;
using Core.Enums;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class ParticipantService : IParticipantService
    {
        #region Private Members
        
        private readonly IUnitOfWork _unitOfWork;

        #endregion
        
        #region Constructor
        
        public ParticipantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        #endregion
        
        #region Implemented Methods
        
        public async Task<IEnumerable<ParticipantPoint>> GetParticipants( string pointName )
        {
            var participantSpec = new ParticipantSpecification ( pointName );
            var participants = await _unitOfWork
                .Repository<ParticipantPoint>()
                .ListAsync ( participantSpec );

            
            // TODO: Add marker column to Participants table
            return participants.Where( x => !x.Initial.Contains("[D]"));
        }

        public async Task<EServiceResponse> CreateParticipant( ParticipantPoint participantPoint, string pointName )
        {
            var pointSpec = new PointSpecification ( pointName );
            var point = await _unitOfWork.Repository<Point>().GetEntityWithSpecAsync ( pointSpec );
            
            
            #region Errors
            
            if( point == null ) return EServiceResponse.PointNotExist;
            if( participantPoint.Initial.Contains("[D]") ) return EServiceResponse.ParticipantWasDeleted;
            if( await IsParticipantWasDeleted(participantPoint.Initial, point.Id) ) return EServiceResponse.ParticipantWasDeleted;
            if( await IsParticipantExist ( participantPoint.Initial, point.Id ) ) return EServiceResponse.ParticipantExist; 
            
            #endregion
            

            var participantToCreate = new ParticipantPoint
            {
                FirstName = participantPoint.FirstName,
                LastName = participantPoint.LastName,
                Initial = participantPoint.Initial,
                PointId = point.Id,
            };


            _unitOfWork.Repository<ParticipantPoint>().Add ( participantToCreate );
            var result = await _unitOfWork.CompleteAsync();

            return result <= 0 ? 
                EServiceResponse.ParticipantCreateFailed : 
                EServiceResponse.ParticipantCreateSuccess;
        }

        public async Task<ParticipantPoint> UpdateParticipant( ParticipantPoint participantPoint, string pointName )
        {
            var pointSpec = new PointSpecification ( pointName );
            var point = await _unitOfWork.Repository<Point>().GetEntityWithSpecAsync ( pointSpec );
            if( point == null ) return null;


            if( await IsParticipantExist ( participantPoint.Initial, point.Id ) ) return null;
            if( await IsDeleted ( participantPoint.Id ) || participantPoint.Initial.Contains("[D]") ) return null;

            
            participantPoint.Point = point;

            
            _unitOfWork.Repository<ParticipantPoint>().DetachLocal ( participantPoint, participantPoint.Id );
            _unitOfWork.Repository<ParticipantPoint>().Update ( participantPoint );
            var result = await _unitOfWork.CompleteAsync();


            return result <= 0 ? null : participantPoint;
        }

        public async Task<EServiceResponse> DeleteParticipant( int id )
        {
            var participant = await _unitOfWork.Repository<ParticipantPoint>().GetByIdAsync ( id );
            if( participant == null ) return EServiceResponse.ParticipantNotExistWhileDelete;
            if (participant.Initial.Contains ( "[D]" ) ) return EServiceResponse.ParticipantWasDeleted;

            participant.Initial += " [D]";
            
            _unitOfWork.Repository<ParticipantPoint>().DetachLocal ( participant, id );
            _unitOfWork.Repository<ParticipantPoint>().Update ( participant );
            var result = await _unitOfWork.CompleteAsync();

            return result <= 0 ? 
                EServiceResponse.ParticipantDeletedFailed : 
                EServiceResponse.ParticipantDeletedSuccess;
        }
        
        #endregion

        private async Task<bool> IsDeleted( int id )
        {
            var participantSpec = new ParticipantSpecification ( id );
            var participant = await _unitOfWork.Repository<ParticipantPoint>().GetEntityWithSpecAsync ( participantSpec );

            return 
                participant != null && 
                participant.Initial.Contains ( "[D]" );
        }

        private async Task<bool> IsParticipantExist( string initial, int pointId )
        {
            var participantSpec = new ParticipantSpecification ( initial, pointId );
            var participant = await _unitOfWork.Repository<ParticipantPoint>().GetEntityWithSpecAsync ( participantSpec );
            return participant != null;
        }
        
        private async Task<bool> IsParticipantWasDeleted( string initial, int pointId )
        {
            var participantSpec = new ParticipantSpecification ( initial + " [D]", pointId );
            var participant = await _unitOfWork.Repository<ParticipantPoint>().GetEntityWithSpecAsync ( participantSpec );
            return participant != null;
        }
    }
}