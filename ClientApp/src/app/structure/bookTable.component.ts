import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Book } from "../models/book.model";
import { Router } from "@angular/router";

@Component({
  selector: "book-table",
  templateUrl: "./bookTable.component.html"
})
export class BookTableComponent {
  constructor(private repo: Repository, private router: Router) {}
  get books(): Book[] {
    return this.repo.books;
  }
  selectBook(id: number) {
    this.repo.getBook(id);
    this.router.navigateByUrl("/detail");
  }
}
