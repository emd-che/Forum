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


  getAllTopics(): Observable<Topic[]> {
      const fullUrl: string = getBaseUrl() + "api/topics";
      console.log(fullUrl);
      return this.http.get<Topic[]>(fullUrl);
  }

  getTopicById(id): Observable<Topic> {
    const fullUrl: string = getBaseUrl() + "api/topics/" + id;
    console.log(fullUrl);
    return this.http.get<Topic>(fullUrl);
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
