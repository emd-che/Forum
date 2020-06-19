import { Component, OnInit, Input } from '@angular/core';
import { Topic } from '../Topic';

@Component({
  selector: 'app-forum-topic',
  templateUrl: './forum-topic.component.html',
  styleUrls: ['./forum-topic.component.css']
})
export class ForumTopicComponent implements OnInit {
  @Input() topic: Topic;
  constructor() { }

  ngOnInit() {
  }

}
