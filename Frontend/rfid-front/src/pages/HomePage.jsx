import Col from "react-bootstrap/Col";
import Container from "react-bootstrap/Container";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";

export default function Homepage() {
  const infoContainer = {
    width: "100%",
    display: "flex",
    justifyContent: "space-between"
  };
  const infoText = {
    border: "3px solid #1715ab",
    width: "35%",
    fontSize: "22px",
    textAlign: "center",
    padding: "20px",
    height: "max-fit-content",
    alignSelf: "baseline",
    margin: "auto 0",
  };
  const infoCreators = {
    display: "flex",
    flexDirection: "column",
    width: "60%",
    fontSize: "22px",
    textAlign: "center",
    padding: "20px",
  };
  const infoCreatorsRow1 = {
    height: "20%",
  };

  return (
    <>
      <div className="infoContainer" style={infoContainer}>
        <div className="infoText" style={infoText}>
          <h2>Информация о продукте</h2>
          <br />
          <p>
            Данный продукт представляет собой сервис, который используется
            работниками авиационных компаний. <br />
            <br />
            Данный сервис позволяет мониторить проверку воздушного судна в
            режиме реального времени, а также получать отчеты об уже завершенных
            проверках.
            <br />
            <br /> Также сервис предоставляет удобный инструмент для агрегации
            данных при помощи дашборда.
          </p>
        </div>
        <div className="infoCreators" style={infoCreators}>
          <Container>
            <div className="infoCreators-row1" style={infoCreatorsRow1}>
              <h2 style={{ marginBottom: "20px", fontWeight: "bold" }}>
                Команда разработчиков
              </h2>
              <Row>
                <Col xs={6} md={4}>
                  <Image src="./photoPolina2.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                    Мельничук Полина, разработка frontend части
                  </p>
                </Col>
                <Col xs={6} md={4}>
                  <Image src="./photoIlya2.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                    Сердюков Илья, разработка backend части
                  </p>
                </Col>
                <Col xs={6} md={4}>
                  <Image src="./user.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                    Малыш Алексей, разработка мобильного приложения
                  </p>
                </Col>
              </Row>
            </div>
          </Container>
          <Container>
            <div className="infoCreators-row2">
              <h2 style={{ margin: "20px 0 ", fontWeight: "bold" }}>
                Дипломные руководители
              </h2>
              <Row>
                <Col xs={6} md={4}>
                  <Image src="./photoRaz.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                    Разживайкин Игорь, старший преподователь кафедры “ЦТУТП”
                  </p>
                </Col>
                <Col xs={6} md={4}>
                  <Image src="./photoZam.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                  Заманов Евгений, старший преподователь кафедры “ЦТУТП”
                  </p>
                </Col>
                <Col xs={6} md={4}>
                  <Image src="./photoZamA.png" roundedCircle />
                  <p style={{ fontSize: "16px", marginTop: "5px" }}>
                  Заманова Елена, старший преподователь кафедры “ЦТУТП”
                  </p>
                </Col>
              </Row>
            </div>
          </Container>
        </div>
      </div>
    </>
  );
}
