import { Component, OnInit } from '@angular/core';

import { Book } from '../book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books: Book[] = [
    {
      id: 1,
      title: "Ready Play One",
      author: "Ernest Cline"
    },
    {
      id: 2,
      title: "Catch 22",
      author: "Joseph Heller"
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
