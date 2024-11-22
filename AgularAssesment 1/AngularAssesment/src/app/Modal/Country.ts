export interface Country {
    countryId: number;       // Unique identifier for the country
    counrtyName: string;     // Name of the country
    isActive?: boolean;      // Optional flag to indicate if the country is active
    isDelete?: boolean;      // Optional flag to indicate if the country is marked for deletion
}
