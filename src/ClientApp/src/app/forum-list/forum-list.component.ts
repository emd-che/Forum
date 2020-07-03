import { Component, OnInit } from '@angular/core';
import { TopicService } from '../topic.service';
import { Topic } from '../model/topic.model';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.css']
})
export class ForumListComponent implements OnInit {

  topics: Topic[];
  constructor(private topicService: TopicService) { }

  ngOnInit() {
    // this.topicServices.getTopics().subscribe(topics => {
    //   this.topics = topics;
    //   console.log("yeah");
    //  });


    //it works!
    // this.topicService.createTopic(
    //   new Topic (0,
    //      "topic created from angular",
    //      "test body",
    //      22,
    //      1, 
    //      null
    //   )
    // ).subscribe(t => {
    //   this.topics.push(t);
    // });


    this.topicService.getAllTopics().subscribe(topics => {
      this.topics = topics;
    }, error => {
      console.error(error);
    }); 
  }


}
