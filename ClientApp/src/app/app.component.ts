import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Task } from './task';
import { Category } from './category';

import { IsLoadingService } from '@service-work/is-loading';
import { DatePipe } from '@angular/common';

//import { HttpResponse } from '@angular/common/http';




@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    task: Task = new Task();        // changeable task
    tasks: Task[];                  // task array

    category: Category = new Category(); // changeable category
    categories: Category[];              // category array

    tableMode: boolean = true;           // tablemode on
    temp: boolean = false;

    date: Date = new Date();
    minDate = new Date(Date.now());
    maxDate = new Date(2025, 1, 1);

    constructor(
        private dataService: DataService,
        private isLoadingService: IsLoadingService) { }

    ngOnInit() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.loadTasks();    // Load tasks on startup  
        this.loadCategories(); // Load categories on startup  

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    dateChanged(evt) {
        let selectedDate = new Date(evt);
        console.log("by default:", selectedDate);
        console.log("by UTCString:", selectedDate.toUTCString());
        console.log("by LocaleString:", selectedDate.toLocaleString());
        console.log("by LocaleTimeString:", selectedDate.toLocaleTimeString());
    }

    // Get tasks through service
    loadTasks() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.dataService.getTasks()
            .subscribe((data: Task[]) => this.tasks = data);

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    // Save data
    save() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        if (this.task.id == null) {
            
            let number = this.task.date.getHours();
            this.task.date.setUTCHours(number+25,number,number,number);
            this.dataService.createTask(this.task)
                .subscribe((data: Task) => this.tasks.push(data));

                //.subscribe((data: HttpResponse<Task>) => { // ##bug with checkbox##
                //    console.log(data);
                //    this.tasks.push(data.body);
                //});
        } else {
            this.dataService.updateTask(this.task)
                .subscribe(data => this.loadTasks());
        }


        //if (this.category.id == null && this.category.name != this.task.category) {
        //    this.category.id = this.task.id + 100;
        //    this.category.name = this.task.category;
        //    this.category.color = "Blue";
        //    this.dataService.createCategory(this.category)
        //        .subscribe((data: Category) => this.categories.push(data));
        //} else {
        //    this.dataService.updateCategory(this.category)
        //        .subscribe(data => this.loadCategories());
        //}
        this.cancel();

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    editTask(temp_task: Task) {
        this.isLoadingService.add({ key: ['default', 'single'] });

        let number = temp_task.date.getHours();
        temp_task.date.setUTCHours(number + 5, number, number, number);
        this.task = temp_task;

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }


    updateMe() {
        this.dataService.getTasks();
        //this.dataService.getCategories();

        console.log("updated");
    }

    checkTask(temp_task: Task) {
        this.isLoadingService.add({ key: ['default', 'single'] });

        temp_task.done = !temp_task.done;

        this.dataService.updateTask(temp_task)
            .subscribe(data => this.loadTasks());
        this.updateMe();    

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    cancel() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.task = new Task();
        this.category = new Category();
        this.tableMode = true;

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    delete(temp_task: Task) {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.dataService.deleteTask(temp_task.id)
            .subscribe(data => this.loadTasks());

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    add() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.cancel();
        this.tableMode = false;

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    // Get categories through service
    loadCategories() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.dataService.getCategories()
            .subscribe((data: Category[]) => this.categories = data);

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    

    editCategory(temp_category: Category) {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.category = temp_category;

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    deleteCategory(temp_category: Category) {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.dataService.deleteCategory(temp_category.id)
            .subscribe(data => this.loadCategories());

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }

    addCategory() {
        this.isLoadingService.add({ key: ['default', 'single'] });

        this.cancel();
        this.tableMode = false;

        this.isLoadingService.remove({ key: ['default', 'single'] });
    }
}