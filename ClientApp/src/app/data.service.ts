import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from './task';
import { Category } from './category';

//  ####### TODO sort by categories, add/delete/modify a category! #######
@Injectable()
export class DataService {

    private url = "/api/tasks";
    private url_for_categories = "/api/categories";

    constructor(private http: HttpClient) {
    }
    // FOR TASKS

    // Returns all tasks from the server
    getTasks() {
        return this.http.get(this.url);
    }


    // Returns a task by id
    getTask(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    // Sends a new object(task) to the server
    createTask(task: Task) {
        return this.http.post(this.url, task);
        //return this.http.post(this.url, task, { observe: 'response' }); ##bug with checkbox##
    }

    // Gets a modified object(task) and sends it to the server with put()
    updateTask(task: Task) {
        return this.http.put(this.url, task);
    }

    // Deletes an object(task) by id
    deleteTask(id: number) {
        return this.http.delete(this.url + '/' + id);
    }


        // FOR CATEGORIES

    // Returns all categories from the server
    getCategories() {
        return this.http.get(this.url_for_categories);
    }

    // Returns a category by id
    getCategory(id: number) {
        return this.http.get(this.url_for_categories + '/' + id);
    }

    // Sends a new object(category) to the server
    createCategory(category: Category) {
        return this.http.post(this.url_for_categories, category);
        //return this.http.post(this.url, task, { observe: 'response' }); ##bug with checkbox##
    }

    // Gets a modified object(category) and sends it to the server with put()
    updateCategory(category: Category) {
        return this.http.put(this.url_for_categories, category);
    }

    // Deletes an object(category) by id
    deleteCategory(id: number) {
        return this.http.delete(this.url_for_categories + '/' + id);
    }
}