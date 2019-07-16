import { Book } from "./book.model";
import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";

const booksUrl = "api/books";

@Injectable()
export class Repository {
  public book: Book;
  constructor(private http: HttpClient, @Inject("BASE_URL") baseurl: string) {
    http.get<Book>(baseurl + "api/books/GetBook").subscribe(
      res => {
        this.book = res;
      },
      error => console.error(error)
    );
    this.getBook(3);
  }
  getBook(id: number) {
    this.http.get(booksUrl + "/" + id).subscribe(res => {
      this.book = res;
    });
  }
}

/*
  getBook(id: number) {
		this.http.get(moviesUrl + "/" + id)
				 .subscribe(response => { this.movie = response });
	}

*/

/*
@Injectable()
export class Repository {
  public bookData: Book;
  constructor(private http: HttpClient, @Inject("BASE_URL") baseurl: string) {
    http.get<Book>(baseurl + "api/books/GetBook").subscribe(
      res => {
        this.bookData = res;
      },
      error => console.error(error)
    );
    this.getBook();
  }
  getBook(): Book {
    // console.log("book req");
    return this.bookData;
  }
}


*/
