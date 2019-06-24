import AuthService from "./AuthService";

export class EventService {
  constructor() {
    this.authService = new AuthService();
  }

  getEvents = () => {
    return this.authService.fetch(
      `${this.authService.corsAddr + this.authService.apiAddr}/events/`,
      null
    );
  };

  getEvent = id => {
    return this.authService.fetch(
      `${this.authService.corsAddr + this.authService.apiAddr}/events/${id}`,
      null
    );
  };

  addEvent = event_params => {
    return this.authService.fetch(
      `${this.authService.corsAddr + this.authService.apiAddr}/events/addevent`,
      { method: "POST", body: JSON.stringify(event_params) }
    );
  };

  observeEvent = id => {
    this.authService.fetch(
      `${this.authService.corsAddr +
        this.authService.apiAddr}/events/addtoobservable/${id}`,
      { method: "PUT" }
    );
  };

  likeEvent = id => {
    this.authService.fetch(
      `${this.authService.corsAddr +
        this.authService.apiAddr}/events/likeevent/${id}`,
      { method: "PUT" }
    );
  };
}
export default EventService;
