import React, {useState} from 'react'
import {Button, Form} from 'semantic-ui-react'
import axios from 'axios';
export default function Create() {
  const [orderStatus, setOrderStatus] = useState('');
  const [shippingStatus, setShippingStatus] = useState('');
  const [orderStatusError, setOrderStatusError] = useState('');
  const [shippingStatusError, setShippingStatusError] = useState('');
  
  const postData = () => {
    setOrderStatusError('');
    setShippingStatusError('');
    axios({
      url : "https://localhost:7024/api/Orders",
      method : "post",
      data:{
        "orderStatus": orderStatus,
        "shippingStatus": shippingStatus  
      }
    }).then((res) => {
      axios
      .get("https://localhost:7024/api/Orders")
      .then((res)=>{
        console.log(res.data);
      });
    }).catch((err)=>{
      setShippingStatusError(err.response.data.errors.ShippingStatus);
      setOrderStatusError(err.response.data.errors.OrderStatus);
    });
    
  }

  return (
    <Form>
      <Form.Field>
        <label>Order Status</label>
        <input placeholder='Order Status' onChange={(e) => setOrderStatus(e.target.value)}/>
        {orderStatusError && (<span className='errorMessage'>{orderStatusError[0]}</span>)} 
      </Form.Field>
      <Form.Field>
        <label>Shipping Status</label>
        <input placeholder='Shipping Status' onChange={(e) => setShippingStatus(e.target.value)}/>
        {shippingStatusError && (<span className='errorMessage'>{shippingStatusError[0]}</span>)}
      </Form.Field>
      <Button type='submit' onClick={postData}>Submit</Button>
    </Form>
  )
}
