import React, { Component } from 'react';

export class HelloWorld extends Component {
    static displayName = HelloWorld.name;
    constructor(props) {
        super(props);
        this.state = { mystr:"",loading:true}
    }

    componentDidMount() {
        this.SayHelloWorld();
    }
    static renderString(str) {
        return (
            <div>
                <strong>{str.message}</strong>
            </div>
        );
    }
    render() {
        let content = this.state.loading
            ? <p><em>Loading...</em></p>
            : HelloWorld.renderString(this.state.mystr);
        return (
            <div>
                <h1 id="tabelLabel" >Saying..!!!</h1>
                <p>This component demonstrates fetching data/string from the server.</p>
                {content}
            </div>
        );
    }
    async SayHelloWorld() {
        const response = await fetch('weatherforecast/SayHello');
        if (response.ok) {
            const data = await response.json();
            this.setState({ mystr: data, loading: false });
        } else {

            this.setState({ mystr: "Nothing to Say :(", loading: false });
        }
    }

}