import { Component, Input } from '@angular/core';
import { ItemInList } from '../../../_models/itemInList.model';

@Component({
    selector: 'app-phones-view-edit',
    templateUrl: './phones-view-edit.component.html',
    styleUrls: ['./phones-view-edit.component.scss']
})
export class PhonesViewEditComponent {
    @Input() elInList: ItemInList;
    @Input() editMode: boolean;

    phoneStates = [
        'Nowy',
        'Używany'
    ];
}
