import { Book } from "./book.model";

export class Rating {
  constructor(
    public ratingId?: number,
    public stars?: number,
    public book?: Book
  ) {}
}
