export default class PeopleApi {
    static getPeople() {
        const uri = "/api/people/all";

        return fetch(uri, {
            method: "GET",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    }

    static getPersonDetails(personId) {
        const uri = `/api/people/${personId}` ;

        return fetch(uri, {
            method: "GET",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    }

    static savePersonDetails(data) {
        const uri = `/api/people/update`;

        return fetch(uri, {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    }
}