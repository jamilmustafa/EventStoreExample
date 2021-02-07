import React, { Component } from 'react';

export class EventStore extends Component {
    static displayName = EventStore.name;

    constructor(props) {
        super(props);
        this.state = { events: [], Balance: 0, loading: true };
    }

    componentDidMount() {
        this.getAllEvents();
    }

    static renderEventsTable(events, balance) {
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>EventId</th>
                            <th>Amount</th>

                        </tr>
                    </thead>
                    <tbody>
                        {events.map(event =>
                            <tr key={event.id}>
                                <td>{event.id}</td>
                                <td>{event.amount}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <h3> Current Balance: {balance}
                    
                </h3>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : EventStore.renderEventsTable(this.state.events, this.state.Balance);

        return (
            <div>
                <h1 id="tabelLabel" >Events</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async getAllEvents() {
        let response = await fetch('EventStore/AllEvents');
        const data = await response.json();

        response = await fetch('EventStore?streamId=' + data.streamId);
        const balance = await response.json();
        this.setState({ events: data.eventModels, Balance: balance, loading: false });
    }
}
