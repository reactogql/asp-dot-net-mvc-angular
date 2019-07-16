import { Book } from "./book.model";
import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Filter } from "./configClasses.repository";
import { Publisher } from "./publisher.model";

const publishersUrl = "api/publishers";
const booksUrl = "api/books";

@Injectable()
export class Repository {
  public book: Book;
  public books: Book[];
  public publishers: Publisher[];
  private filterObject = new Filter();
  constructor(private http: HttpClient) {
    this.filter.related = true;
    this.getBooks();
  }
  getBook(id: number) {
    this.http.get(booksUrl + "/" + id).subscribe(res => {
      this.book = res;
    });
  }
  getBooks(related = false) {
    let url = booksUrl + "?related=" + related;
    if (this.filter.category) {
      url += "&category=" + this.filter.category;
    }
    if (this.filter.search) {
      url += "&search=" + this.filter.search;
    }
    this.http.get<Book[]>(url).subscribe(res => (this.books = res));
  }
  getPublishers() {
    this.http
      .get<Publisher[]>(publishersUrl)
      .subscribe(res => (this.publishers = res));
  }
  createBook(book: Book) {
    const publisher = book.publisher ? book.publisher.publisherId : 0;
    const data = {
      Image: book.image,
      Title: book.title,
      Category: book.category,
      Description: book.description,
      Price: book.price,
      Writer: book.writer,
      Publisher: publisher
    };
    this.http.post<number>(booksUrl, data).subscribe(res => {
      book.bookId = res;
      this.books.push(book);
    });
  }
  createBookAndPublisher(book: Book, publisher: Publisher) {
    const data = {
      Name: publisher.name,
      City: publisher.city,
      State: publisher.state
    };
    this.http.post<number>(publishersUrl, data).subscribe(res => {
      publisher.publisherId = res;
      this.publishers.push(publisher);
      if (book != null) {
        book.publisher = publisher;
        this.createBook(book);
      }
    });
  }
  replaceBook(book: Book) {
    const data = {
      Image: book.image,
      Title: book.title,
      Category: book.category,
      Description: book.description,
      Price: book.price,
      Writer: book.writer,
      Publisher: book.publisher ? book.publisher.publisherId : 0
    };
    this.http
      .put(booksUrl + "/" + book.bookId, data)
      .subscribe(response => this.getBooks());
  }
  replacePublisher(publisher: Publisher) {
    const data = {
      name: publisher.name,
      city: publisher.city,
      state: publisher.state
    };
    this.http
      .put(publishersUrl + "/" + publisher.publisherId, data)
      .subscribe(response => this.getBooks());
  }
  updateBook(id: number, changes: Map<string, any>) {
    const patch = [];
    changes.forEach((value, key) =>
      patch.push({ op: "replace", path: key, value: value })
    );
    this.http
      .patch(booksUrl + "/" + id, patch)
      .subscribe(response => this.getBooks());
  }
  deleteBook(id: number) {
    this.http
      .delete(booksUrl + "/" + id)
      .subscribe(response => this.getBooks());
  }
  deletePublisher(id: number) {
    this.http.delete(publishersUrl + "/" + id).subscribe(response => {
      this.getBooks();
      this.getPublishers();
    });
  }

  get filter(): Filter {
    return this.filterObject;
  }
}
