import logo from './logo.svg';
import './App.css';
import {Route, Routes, Redirect, Switch , Navigate} from 'react-router-dom'
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Header from './components/shared/header';
import Shows from './components/show/shows';
import Alarm from './components/alarm/alarmPage';
import Home from './components/shared/home';
import NotFound from './components/shared/notFound';
import AlarmConfirmation from './components/alarm/alarmConfirmation';
import Footer from './components/shared/footer';

function App() {
  return (
    <main >
    <Header></Header>
    <ToastContainer></ToastContainer>
    <div className='content'>
 
      <Routes>
       
        <Route path="/alarm/:id" Component={Alarm}></Route>
        <Route path="/confirmation" Component={AlarmConfirmation}></Route>
        <Route path="/" Component={Home}></Route>
        <Route path="/404" Component={NotFound} />
        <Route path="*" element={<Navigate replace to="/404" />} />
        
        {/*
        <Route path="/bonjour/:id"  Component={ShowPage}  ></Route>
        <Route path="/bonjour"  render={(props) => <ShowPage sortBy="test" {...props}></ShowPage>}>AAAAAAAA</Route>
        <Route path="/bonjour2"   Component={ShowPage}  >AAAAAAAA</Route>
        <Route path="/monform"   Component={MonForm}  >monform</Route> */}
      </Routes>
    </div>
    <Footer></Footer>
  </main>

  );
}

export default App;
