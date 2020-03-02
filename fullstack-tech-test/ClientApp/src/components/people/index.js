import React, { Component } from 'react';
import { connect } from 'react-redux';
import { loadPeople } from '../people/people-actions';
import PeopleListing from '../people/people-listing';
import { bindActionCreators } from 'redux';
import 'semantic-ui-css/semantic.min.css';
import Spinner from '../../components/spinner';

class People extends Component {
    
    async componentDidMount() {
        await this.props.loadPeople();
    }

    render() {
        if (this.props.loading) {
            return <Spinner/>
        }

        if (this.props.error) {
            return <div style={{ color: 'red' }}>ERROR: {this.props.error}</div>
        }

        return (

            <div className="people-listing">
                <h1>People</h1>
                <PeopleListing data={this.props.data} />
            </div>
        );
    }
}

const mapStateToProps = state => ({
    error: state.peopleData.error,
    data: state.peopleData.data,
    loading: state.peopleData.loading
});

function mapDispatchToProps(dispatch) {
    return {
        loadPeople: bindActionCreators(loadPeople, dispatch)
    }
}

const PeopleView = connect(mapStateToProps, mapDispatchToProps)(People);

export default PeopleView;