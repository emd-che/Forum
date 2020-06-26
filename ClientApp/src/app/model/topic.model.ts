import { User } from "./user.model";
import { CommentM } from "./comment.model";

export class Topic {
    constructor(
        public id?: number,
        public title?: string,
        public body?: string,
        public viewCount?: number,
        public user?: User,
        public comments?: CommentM[]   
    ) {}
}