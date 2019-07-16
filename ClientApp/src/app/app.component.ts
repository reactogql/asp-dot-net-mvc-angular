import { Component } from "@angular/core";
import { Repository } from "./models/repository";
import { Book } from "./models/book.model";
import { Publisher } from "./models/publisher.model";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "The Book Rating App";
  constructor(private repo: Repository) {}
  get book(): Book {
    return this.repo.book;
  }
  get books(): Book[] {
    return this.repo.books;
  }

  createBook() {
    this.repo.createBook(
      new Book(
        0,
        "X-Men Final Chapter",
        "Drama",
        "After the re-emergence of the world's first mutant, " +
          "the world-destroyer Apocalypse, the X-Men must unite to defeat his car",
        "Moris Miver",
        "bit.ly/2D8C6ha",
        49.99,
        this.repo.books[0].publisher
      )
    );
  }

  createBookAndPublisher() {
    const s = new Publisher(0, "SkyBooks", "Brooklyn", "NY");
    const m = new Book(
      0,
      "Chef Time",
      "Romance",
      "A head chef quits his relation",
      "Home Cats",
      "bit.ly/2D7Vtqo",
      100,
      s
    );
    this.repo.createBookAndPublisher(m, s);
  }

  replaceBook() {
    const m = this.repo.books[0];
    m.title = "Modified Title";
    m.category = "Modified Category";
    this.repo.replaceBook(m);
  }

  replacePublisher() {
    const s = new Publisher(3, "Modified Studio", "New York", "NY");
    this.repo.replacePublisher(s);
  }

  updateBook() {
    const changes = new Map<string, any>();
    changes.set("name", "Green Hornet");
    changes.set("studio", null);
    this.repo.updateBook(1, changes);
  }
  deleteBook() {
    this.repo.deleteBook(1);
  }
  deletePublisher() {
    this.repo.deletePublisher(2);
  }
}
