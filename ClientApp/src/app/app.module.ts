import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { ModelModule } from "./models/model.module";

import { BookTableComponent } from "./structure/bookTable.component";
import { CategoryFilterComponent } from "./structure/categoryFilter.component";
import { BookDetailComponent } from "./structure/bookDetail.component";
import { RoutingConfig } from "./app.routing";

@NgModule({
  declarations: [
    BookDetailComponent,
    BookTableComponent,
    CategoryFilterComponent,
    AppComponent
  ],
  imports: [
    RoutingConfig,
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    ModelModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
