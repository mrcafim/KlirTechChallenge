import { CommonModule } from '@angular/common';
import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        NgxPaginationModule,
        RouterModule
    ],
    exports: [
        CommonModule,
        NgxPaginationModule
    ],
    providers: []
})
export class ShareModule {}
