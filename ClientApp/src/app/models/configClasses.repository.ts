export class Filter {
  category?: string;
  search?: string;
  // tslint:disable-next-line
  related: boolean = false;
  reset() {
    this.category = this.search = null;
    this.related = false;
  }
}
