import { Component, OnInit } from '@angular/core';
import { Topic } from '../model/topic.model';
import { TopicService } from '../topic.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.css']
})
export class CreateTopicComponent implements OnInit {

// TODO: add form builder

  constructor(private topicService: TopicService, private router: Router) { }

  model: TopicInput = new TopicInput();
  ngOnInit() {
  }

  onSubmit(){
    const topic:Topic = {
      title: this.model.title,
      body: this.model.body,
      userId: +this.model.userId
    } 
   
    this.createTopic(topic);
  }

  createTopic(topic){
   
  
    this.topicService.createTopic(topic).subscribe(t => {
      this.router.navigateByUrl("/");
    }, error => {
      console.error(error);
    });
  }

}

class TopicInput {
 
  constructor(
    public title?: string,
    public body?: string,
    public userId?: string 
  ) {}
}