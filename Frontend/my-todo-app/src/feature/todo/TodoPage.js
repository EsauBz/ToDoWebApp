import React, {Component} from 'react';
import {connect } from 'react-redux';
import { getTodos } from '../../redux/selectors/todoSelectors';

export default class TodoPage extends Component {
    render() {
        return(
            <div>

            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        todos:getTodos(state)
    }
}

export default connect(mapStateToProps)(TodoPage);
