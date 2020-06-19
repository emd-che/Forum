import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { switchMap } from 'rxjs/operators'
import { TopicService } from '../topic.service';
import { Topic } from '../Topic';

//import  "rxjs/operator/switchMap";
@Component({
  selector: 'app-forum-topic-detail',
  templateUrl: './forum-topic-detail.component.html',
  styleUrls: ['./forum-topic-detail.component.css']
})
export class ForumTopicDetailComponent implements OnInit {
  topic: Topic;

  constructor(private route: ActivatedRoute, private topicService: TopicService) { }

  ngOnInit() {
    this.route.params
      .pipe(switchMap((params: Params) => this.topicService.getTopicById(+params['id'])))
      .subscribe((topic) => this.topic = topic);
    // this.route.queryParams.subscribe(params =>{
    //   this.testId = params['id']; 
    // });
    // console.log(this.route.snapshot.params['id']);  
    // console.log(this.testId);
  }

}
