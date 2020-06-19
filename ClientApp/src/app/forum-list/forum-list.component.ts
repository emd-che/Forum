import { Component, OnInit } from '@angular/core';
import { TopicService } from '../topic.service';
import { Topic } from '../Topic';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.css']
})
export class ForumListComponent implements OnInit {

  topics: Topic[];
  constructor(private topicServices: TopicService) { }

  ngOnInit() {
    // this.topicServices.getTopics().subscribe(topics => {
    //   this.topics = topics;
    //   console.log("yeah");
    //  });
    this.topicServices.getAllTopics().subscribe(topics => {
      this.topics = topics;
    }, error => {
      console.error(error);
    });
    
  }
}
