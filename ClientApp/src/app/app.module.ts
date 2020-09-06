import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DatePipe } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSpinnerOverlayComponent } from './mat-spinner-overlay/mat-spinner-overlay.component';
import { IsLoadingModule } from '@service-work/is-loading';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CategoryBlockComponent } from './category-block/category-block.component';





@NgModule({
    imports: [BrowserModule, BrowserAnimationsModule, FormsModule, HttpClientModule, MatDatepickerModule, MatNativeDateModule, MatCheckboxModule, IsLoadingModule, MatProgressSpinnerModule],
    providers: [DatePipe, MatDatepickerModule],
    declarations: [AppComponent, MatSpinnerOverlayComponent, CategoryBlockComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }