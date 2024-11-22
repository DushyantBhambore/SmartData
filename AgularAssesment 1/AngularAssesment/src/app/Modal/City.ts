export interface City {
    cityId: number;          // Unique identifier for the city
    cityName: string;        // Name of the city
    stateId: number;         // Foreign key to the state this city belongs to
}
