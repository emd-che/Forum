import  { CommentM } from "./comment.model";
import { Topic } from "./topic.model"; 

export class User {
    constructor(
        public id?: number,
        public username?: string,
        public email?: string,
        public topic?: Topic[],
        public comments?: CommentM[],
    ) {}
}