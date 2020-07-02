import { Injectable } from '@angular/core';
import { CommentM } from './model/comment.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  createComment(comment: CommentM): Observable<any>{
    let commentsUrl:string = getBaseUrl() + "api/comments" ;
    let data: CommentM = {
      commentBody : comment.commentBody,
      userId : comment.userId ? comment.userId: 0,
      topicId : comment.topicId? comment.topicId: 0
    };
    return this.http.post<CommentM>(commentsUrl, data, httpOptions);
  }
}
