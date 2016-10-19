export class Schedule {
    SeasonName: string;
    Weeks: Week[];
}

export class Week {
    Name: string;
    Games: Game[];
}

export class Game {
    StartTime: Date;
    HomeTeam: Team;
    VisitingTeam: Team;
    HomeTeamScore: number;
    VisitingTeamScore: number;
}

export class Team {
    City: string;
    Name: string;
    LogoURL: string;
}