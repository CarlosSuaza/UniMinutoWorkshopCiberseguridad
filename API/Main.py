
# Main:

import uvicorn

def start():
    uvicorn.run(
        "application.webapiflujodata:app",
        host = "127.0.0.1",
        port = 8070,
        reload = True
    )

def start():
    uvicorn.run(
        "application.webapiflujodata:app",
        host = "127.0.0.1",
        port=8432,
        reload=True
    )

def startssl():
    uvicorn.run(
        "application.webapiflujodata:app",
        host = "127.0.0.1",
        port=8432,
        reload=True,
        ssl_keyfile="./key.pem",
        ssl_certfile="./cert.pem"
    )


if __name__ == "__main__":
    start()
    #startssl()