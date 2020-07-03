import { Component, OnInit, Input } from '@angular/core';
import { CommentM } from '../model/comment.model';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  @Input() comment: CommentM;
  constructor() { }

  ngOnInit() {
  }

}
