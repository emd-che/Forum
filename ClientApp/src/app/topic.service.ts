import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { Topic } from './model/topic.model';

@Injectable({
  providedIn: 'root'
})
export class TopicService {
  
  topics: Topic[];
  constructor(private http: HttpClient ) { }


  getAllTopics(search = "", related = false): Observable<Topic[]> {
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
  // getTopics(): Observable<Topic[]>{
  //   return of( [
  //     {
  //       topicTitle: "test topic one",
  //       repliesCount: 20,
  //       viewsCount: 100,
  //       activity: 4,
  //     },
  //    {
  //       topicTitle: "test topic two",
  //       repliesCount: 15,
  //       viewsCount: 80,
  //       activity: 2,
  //     }
  //   ]);

  // }
}
