import { Publisher } from "./publisher.model";
import { Rating } from "./rating.model";

export class Book {
  constructor(
    public bookId?: number,
    public name?: string,
    public category?: string,
    public description?: string,
    public price?: number,
    public publisher?: Publisher,
    public ratings?: Rating[]
  ) {}
}
