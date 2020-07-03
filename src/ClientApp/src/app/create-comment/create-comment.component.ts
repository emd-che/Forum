import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { CommentM } from '../model/comment.model';
import { Topic } from '../model/topic.model';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {
  @Input() topic: Topic;
  @Output() createComment: EventEmitter<any> = new EventEmitter; 

  constructor() { }
  model: CommentInput = new CommentInput();
  ngOnInit() {
  }
  onSubmit(){
    const comment:CommentM = {
      commentBody: this.model.commentBody,
      userId: +this.model.userId,
      topicId: +this.topic.id
    } 
    this.createComment.emit(comment);
  }

}


class CommentInput {
 
  constructor(
    public commentBody?: string,
    public userId?: string,
    public topicId?: string 
  ) {}
}
