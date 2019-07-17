import { Routes, RouterModule } from "@angular/router";
import { BookTableComponent } from "./structure/bookTable.component";
import { BookDetailComponent } from "./structure/bookDetail.component";

const routes: Routes = [
  { path: "table", component: BookTableComponent },
  { path: "detail/:id", component: BookDetailComponent },
  { path: "detail", component: BookDetailComponent },
  { path: "", component: BookTableComponent }
];

export const RoutingConfig = RouterModule.forRoot(routes);
