import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Book } from "../models/book.model";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "book-detail",
  templateUrl: "bookDetail.component.html"
})
export class BookDetailComponent {
  constructor(
    private repo: Repository,
    router: Router,
    activeRoute: ActivatedRoute
  ) {
    const id = Number.parseInt(activeRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getBook(id);
    } else {
      router.navigateByUrl("/");
    }
  }
  get movie(): Book {
    return this.repo.book;
  }
}
