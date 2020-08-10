import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ForumListComponent } from './forum-list/forum-list.component';
import { ForumTopicComponent } from './forum-topic/forum-topic.component';
import { ForumTopicDetailComponent } from './forum-topic-detail/forum-topic-detail.component';
import { CommentComponent } from './comment/comment.component';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { CreateCommentComponent } from './create-comment/create-comment.component';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminGuard } from './guards/admin.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ForumListComponent,
    ForumTopicComponent,
    ForumTopicDetailComponent, 
    CommentComponent, 
    CreateTopicComponent,
    CreateCommentComponent,
    LoginComponent,
    AdminDashboardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ForumListComponent, pathMatch: 'full' },
      { path: 'topic/create', component: CreateTopicComponent },
      { path: 'topic/:id', component: ForumTopicDetailComponent },
      { path: 'login', component: LoginComponent },
      { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AdminGuard]}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
