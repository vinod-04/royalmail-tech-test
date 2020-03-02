import React from "react";
import jest from "jest";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";

import People from '../people';
//import PeopleListing from '../people/people-listing';

let container;

beforeEach(() => {
    container = document.createElement("div");
    document.body.appendChild(container);
});

afterEach(() => {
    unmountComponentAtNode(container);
    container.remove();
    container = null;
});

describe("People component", () => {
    test("it shows a list of people", async () => {
        const fakeResponse = [{ "personId": 1, "firstName": "David", "lastName": "Hirst", "isAdmin": false, "isValid": true, "isEnabled": false, "personSkills": [{ "personId": 1, "skillId": 1, "person": null, "skill": null }, { "personId": 1, "skillId": 2, "person": null, "skill": null }, { "personId": 1, "skillId": 3, "person": null, "skill": null }] }, { "personId": 2, "firstName": "Nigel", "lastName": "Pearson", "isAdmin": false, "isValid": false, "isEnabled": false, "personSkills": [{ "personId": 2, "skillId": 1, "person": null, "skill": null }, { "personId": 2, "skillId": 2, "person": null, "skill": null }, { "personId": 2, "skillId": 3, "person": null, "skill": null }] }];

        jest.spyOn(window, "fetch").mockImplementation(() => {
            const fetchResponse = {
                json: () => Promise.resolve(fakeResponse)
            };
            return Promise.resolve(fetchResponse);
        });

        await act(async () => {
            render(<People />, container);
        });

        //Todo: Incomplete unit testing
        expect(container.textContent).toBe("David Hirst");

        window.fetch.mockRestore();
    });
});