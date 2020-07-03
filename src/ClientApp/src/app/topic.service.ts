import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { Topic } from './model/topic.model';




const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}


@Injectable({
  providedIn: 'root'
})
export class TopicService {
  
  topics: Topic[];
  constructor(private http: HttpClient ) { }


  getAllTopics(search = "", related = true): Observable<Topic[]> {
      let topicsUrl:string = getBaseUrl() + "api/topics" ;
        topicsUrl += "?related=" + related;

      if (search){
        topicsUrl += "&search=" + search;
      } 
      
      console.log(topicsUrl);
      return this.http.get<Topic[]>(topicsUrl);
  }

  getTopicById(id): Observable<Topic> {
    const topicUrl: string = getBaseUrl() + "api/topics/" + id;
    console.log(topicUrl);
    return this.http.get<Topic>(topicUrl);
  }

  createTopic(topic: Topic): Observable<any>{
    let topicsUrl:string = getBaseUrl() + "api/topics" ;
    let data: Topic = {
      title : topic.title,
      body : topic.body,
      userId : topic.userId ? topic.userId: 0
    };
    return this.http.post<Topic>(topicsUrl, data, httpOptions);
  }

 

 
}
