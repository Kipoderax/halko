import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { PhonesAddComponent } from './phones-add/phones-add.component';
import { PhonesListArchiveComponent } from './phones-list-archive/phones-list-archive.component';
import { PhonesDetailsComponent } from './phones-list/phones-item/phones-details/phones-details.component';
import { PhonesSoldComponent } from './phones-list/phones-item/phones-details/phones-sold/phones-sold.component';
import { PhonesTransferComponent } from './phones-list/phones-item/phones-details/phones-transfer/phones-transfer.component';
import { PhonesViewEditComponent } from './phones-list/phones-item/phones-details/phones-view-edit/phones-view-edit.component';
import { PhonesItemComponent } from './phones-list/phones-item/phones-item.component';
import { PhonesListComponent } from './phones-list/phones-list.component';
import { PhonesSeacherComponent } from './phones-seacher/phones-seacher.component';
import { PhonesComponent } from './phones.component';

@NgModule({
    declarations: [
        PhonesComponent,
        PhonesItemComponent,
        PhonesSeacherComponent,
        PhonesDetailsComponent,
        PhonesViewEditComponent,
        PhonesSoldComponent,
        PhonesTransferComponent,
        PhonesListComponent,
        PhonesListArchiveComponent,
        PhonesAddComponent
    ],
    exports: [
        PhonesSeacherComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            {
                path: '',
                component: PhonesComponent,
                children: [
                    {path: '', component: PhonesListComponent},
                    {path: 'archiwum', component: PhonesListArchiveComponent},
                    {path: 'dodaj-telefon', component: PhonesAddComponent}
                ]
            }
        ])
    ]
})
export class PhonesModule {}
