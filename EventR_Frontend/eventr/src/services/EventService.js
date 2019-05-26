import AuthService from "./AuthService";

export class EventService {
  constructor() {
    this.authService = new AuthService();
  }

  getEvents = () => {
    return this.authService.fetch(`${this.authService.apiAddr}/events/`, null);
  };

  getEvent = id => {
    return this.authService.fetch(
      `${this.authService.apiAddr}/events/${id}`,
      null
    );
  };

  addEvent = event_params => {
    //TODO: zrobić
  };
}
export default EventService;
