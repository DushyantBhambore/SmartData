export interface State {
    stateId: number;         // Unique identifier for the state
    stateName: string;       // Name of the state
    countryId: number;       // Foreign key to the country this state belongs to
}
