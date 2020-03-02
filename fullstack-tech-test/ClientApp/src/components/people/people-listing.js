import React from 'react';
import { Table, Label } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { skillsMapping } from '../people/skills-service';

import map from 'lodash/map';
import sortBy from 'lodash/sortBy';
import join from 'lodash/join';
import groupBy from 'lodash/groupBy';

class PeopleListing extends React.Component {

    //Array to hold people skills
    peopleSkills = [];

    constructor(props) {
        super(props)

        //Add person skills to an array
        let personSkills = map(this.props.data, 'personSkills');
        map(personSkills, (obj) => {
            this.peopleSkills.push({ skills: join(map(sortBy(obj), 'skillId'), ',') });
        });
    }

    renderSkills = (data) => {
        let personSkills = [];
        
        map(data, (item) => {
            personSkills.push(skillsMapping[item.skillId]);
        });

        return join(personSkills, ", ");
    }

    render() {
        return (
            <Table singleLine>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Name</Table.HeaderCell>
                        <Table.HeaderCell>Admin</Table.HeaderCell>
                        <Table.HeaderCell>Enabled</Table.HeaderCell>
                        <Table.HeaderCell>Skills</Table.HeaderCell>
                        <Table.HeaderCell>Matching Skills</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>

                <Table.Body>
                    {
                        this.props.data.map((item, i) => {
                            //logic matching skills count
                            let personSkills = join(map(sortBy(item.personSkills), 'skillId'), ',');

                            //group skills by a skill set
                            let matchedSkills = groupBy(this.peopleSkills, { skills: personSkills });
                            let skillCount = matchedSkills ? matchedSkills.true.length : 0;
                           
                            return <Table.Row key={i}>
                                <Table.Cell><Link to={`/people/${item.personId}`}>{item.firstName} {item.lastName}</Link></Table.Cell>
                                <Table.Cell>{item.isAdmin ? <Label color="green">Yes</Label> : <Label color="red">No</Label>}</Table.Cell>
                                <Table.Cell>{item.isEnabled ? <Label color="green">Yes</Label> : <Label color="red">No</Label>}</Table.Cell>
                                <Table.Cell>{this.renderSkills(item.personSkills)}</Table.Cell>
                                <Table.Cell>{skillCount}</Table.Cell>
                            </Table.Row>
                        })
                    }
                </Table.Body>
            </Table>
        );
    }
}

export default PeopleListing;