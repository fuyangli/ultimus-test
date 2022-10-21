import React, { Component } from 'react';

export class Orders extends Component {
    static displayName = Orders.name;

    constructor(props) {
        super(props);
        this.state = { orders: [], loading: true, timeOfDay: "morning", dishes: "" };

        this.handleTimeOfDayChange = this.handleTimeOfDayChange.bind(this);
        this.handleDishesChange = this.handleDishesChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.renderForm = this.renderForm.bind(this);
    }

    componentDidMount() {
        this.populateOrdersData();
    }

    handleTimeOfDayChange(event) {
        this.setState({ timeOfDay: event.target.value });
    }

    handleDishesChange(event) {
        this.setState({ dishes: event.target.value });
    }

    async handleSubmit(event) {
        event.preventDefault();
        var json = {
            items: this.state.dishes.split(" "),
            timeOfDay: this.state.timeOfDay
        };

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(json)
        };
        var response = await fetch("Order", requestOptions);
        var data = await response.json();
        this.setState({ orders: this.state.orders.concat(data) });
       
    }

    renderForm() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <div class="row">
                        <div class="col">
                            <select class="form-control" value={this.state.timeOfDay} onChange={this.handleTimeOfDayChange}>
                                <option value="morning">Morning</option>
                                <option value="night">Night</option>
                            </select>
                        </div>
                        <div class="col">
                            <input class="form-control" value={this.state.dishes} onChange={this.handleDishesChange} placeholder="List the Dishes in this pattern (ex): 1 2 3" type="text"></input>
                        </div>
                    </div>
                </form>
            </div>
        );
    }

    static renderOrder(orders) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Period</th>
                        <th>Items</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map(order =>
                        <tr key={order}>
                            <td>{order.timeOfDay}</td>
                            <td>
                                <ul>
                                    {order.items.map(item => <li key={item}>{item}</li>)}
                                </ul>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Orders.renderOrder(this.state.orders);

        return (
            <div>
                <h1 id="tabelLabel" >Orders</h1>
                {this.renderForm()}
                {contents}
            </div>
        );
    }

    async populateOrdersData() {
        const response = await fetch('Order');
        const data = await response.json();
        this.setState({ orders: data, loading: false });
    }
}
