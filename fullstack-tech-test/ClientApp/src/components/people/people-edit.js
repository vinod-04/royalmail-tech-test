import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from 'react-redux';
import { fetchPersonDetails } from '../people/people-actions';
import { bindActionCreators } from 'redux';
import { Button, Checkbox, Form, Message } from 'semantic-ui-react'
import PeopleApi from '../people/people-api';
import Spinner from '../../components/spinner';

import 'semantic-ui-css/semantic.min.css';

class PersonEditForm extends Component {
    state = {
        personId: 0,
        isAdmin: false,
        isEnabled: false,
        csharp: false,
        javascript: false,
        java: false,
        formLoaded: false,
        formUpdated: false,
        formUpdatedError: false,
        loading: false
    }

    componentDidMount() {
        if (this.props.match.params.personId) {
            this.props.fetchPersonDetails(this.props.match.params.personId, this.state);
        }
    }

    handleUserDetailsChange = (e, data) => {
        this.setState({ [data.name]: data.checked });
    }

    personSkillHandler = (skills, skillId) => {
        if (skills) {
            return skills.some(skill => skillId === skill.skillId);
        }
        return false;
    }

    handleSubmit = (e) => {
        e.preventDefault();
        this.setState({ loading: true });

        let postData = { personId: this.state.personId, isAdmin: this.state.isAdmin, isEnabled: this.state.isEnabled };
        let skillIds = [];

        if (this.state.csharp) skillIds.push(1);
        if (this.state.javascript) skillIds.push(2);
        if (this.state.java) skillIds.push(3);

        postData.skillIds = skillIds;

        PeopleApi.savePersonDetails(postData)
            .then(res => res.json())
            .then((res) => {
                this.setState({ formUpdated: res.success, loading: false, formUpdatedError: false });

                if (res.success) {
                    setTimeout(() => {
                        this.props.history.push('/people');
                    }, 1500)
                }
            })
            .catch((err) => {
                console.log(err)
                this.setState({ formUpdated: false, loading: false, formUpdatedError: true });
            });
    }

    render() {
        if (this.state.loading) {
            return <Spinner />
        }

        if (this.props.error) {
            return <div style={{ color: 'red' }}>ERROR: {this.props.error}</div>
        }

        return (
            <div>
                {this.state.formLoaded &&
                    <Form onSubmit={this.handleSubmit}>
                        <Message header={`Update ${this.props.data.firstName} ${this.props.data.lastName}`} />
                        <Form.Group grouped>
                            <label>User Details</label>
                            <br />
                            <Checkbox label="Admin" checked={this.state.isAdmin} onChange={this.handleUserDetailsChange} name="isAdmin" />
                            <br />
                            <Checkbox label="Enabled" checked={this.state.isEnabled} onChange={this.handleUserDetailsChange} name="isEnabled" />
                        </Form.Group>
                        <Form.Group grouped>
                            <label>Skills</label>
                            <br />
                            <Checkbox label='C#' checked={this.state.csharp} value="1" onChange={this.handleUserDetailsChange} name="csharp" />
                            <br />
                            <Checkbox label='Javascript' checked={this.state.javascript} value="2" onChange={this.handleUserDetailsChange} name="javascript" />
                            <br />
                            <Checkbox label='Java' checked={this.state.java} value="3" onChange={this.handleUserDetailsChange} name="java" />
                        </Form.Group>
                        {this.state.formLoaded && < Button primary type='submit'>Save Changes</Button>}
                        <Button secondary as={Link} to="/people">Cancel</Button>
                    </Form>
                }

                {
                    this.state.formUpdated && <Message positive>
                        <Message.Header>Updated successfully</Message.Header>
                    </Message>
                }

                {
                    this.state.formUpdatedError && <Message negative>
                        <Message.Header>Unable to update</Message.Header>
                    </Message>
                }
            </div>
        );
    }
}

const mapStateToProps = state => ({
    error: state.personData.error,
    data: state.personData.data,
    loading: state.personData.loading,
    personId: state.personId
});

function mapDispatchToProps(dispatch) {
    return {
        fetchPersonDetails: bindActionCreators(fetchPersonDetails, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(PersonEditForm);