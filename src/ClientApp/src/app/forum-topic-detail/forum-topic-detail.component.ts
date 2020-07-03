import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { switchMap } from 'rxjs/operators'
import { TopicService } from '../topic.service';
import { Topic } from '../model/topic.model';
import { CommentService } from '../comment.service';
import { CommentM } from '../model/comment.model';

//import  "rxjs/operator/switchMap";
@Component({
  selector: 'app-forum-topic-detail',
  templateUrl: './forum-topic-detail.component.html',
  styleUrls: ['./forum-topic-detail.component.css']
})
export class ForumTopicDetailComponent implements OnInit {
  topic: Topic;
  comments: CommentM[];
//maybe add comments property for live update?
  constructor(private route: ActivatedRoute,
    private topicService: TopicService,
    private commentService: CommentService) { }

  ngOnInit() {
    this.route.params
      .pipe(switchMap((params: Params) => this.topicService.getTopicById(+params['id'])))
      .subscribe((topic) => {
        this.topic = topic;
        this.comments = topic.comments;
      });
    // this.route.queryParams.subscribe(params =>{
    //   this.testId = params['id']; 
    // });
    // console.log(this.route.snapshot.params['id']);  
    // console.log(this.testId);
  }
  createComment(comment){

    this.commentService.createComment(comment).subscribe(c => {
      console.log(c);
      this.comments.push(c);
    }, error => {
      console.error(error);
    });
  }
}

