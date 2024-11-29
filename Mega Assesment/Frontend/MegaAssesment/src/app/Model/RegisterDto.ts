export interface RegisterDto {
        id: number,
        firstName: string,
        lastName: string,
        email: string,
        mobile: string,
        dob: Date,
        roleId: number,
        productImage: string,
        imageFile: string,
        address: string,
        zipcode: number,
        stateId: number,
        countryId: number
}