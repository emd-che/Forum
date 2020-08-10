import  { CommentM } from "./comment.model";
import { Topic } from "./topic.model"; 

export class User {
    constructor(
        public id?: number,
        public username?: string,
        public email?: string,
        public role?: string,
        public isLoggedIn?: boolean,
        public topic?: Topic[],
        public comments?: CommentM[],
    ) {}
}