package main

import (
	"encoding/json"
	"fmt"
	"io"
	"io/ioutil"
	"net/http"
	"os"

	"github.com/abema/go-mp4"
	"github.com/sunfish-shogi/bufseekio"
)

const (
	videoBaseURL = "https://tiktok-video-no-watermark2.p.rapidapi.com/user/posts"
	userID       = "@missgrand2021.thuytien"
	// videoLink    = "https://v16m.tiktokcdn.com/31cb4a6d135d5bdaf81253a5542f1afd/647b97e1/video/tos/useast2a/tos-useast2a-ve-0068c003/oAAAD07tR4EyfgANIvCuIGOzohvCk6QmxdPrUJ/?a=1340&ch=0&cr=3&dr=0&lr=all&cd=0%7C0%7C0%7C3&cv=1&br=5348&bt=2674&cs=0&ds=6&ft=kLsdJyD9Z4Y0PD1lWzlXg9wNMSQLvEeC~&mime_type=video_mp4&qs=0&rc=Omg7Nzs1aThmN2c4aWZpOEBpM2hxc2c6Znc0azMzNzczM0AzM2BiMTNgNl8xLS82MS1iYSNrNWdscjRvY3BgLS1kMTZzcw%3D%3D&l=20230603134318D682DB8D25498A9A0DE1&btag=e00080000&cc=3"
)

type (
	Client struct {
		httpClient *http.Client
	}
	UserPostVideoResponse struct {
		ListVideo Data `json:"data"`
	}

	Data struct {
		Videos []VideoData `json:"videos"`
	}
	VideoData struct {
		PlayVid string `json:"play"`
	}
)

func main() {
	fmt.Println("Main start")
	cli := &Client{
		httpClient: &http.Client{},
	}
	listVideo := cli.getListVideo()
	for i := range listVideo.ListVideo.Videos {
		cli.DownloadVideo(listVideo.ListVideo.Videos[i].PlayVid, i)
	}
}

func (c *Client) DownloadVideo(videoPath string, id int) (interface{}, error) {
	if videoPath == "" {
	// donwload
	request, err := http.NewRequest("GET", videoPath, nil)
	if err != nil {
		fmt.Println(err)
	}
	resp, err := c.httpClient.Do(request)
	if err != nil {
		fmt.Println(err)
	}
	inputFile, err := os.Create("../../TikTokVid/resVideo")
	if err != nil {
		fmt.Println(err)
	}
	// bytes
	// body, err := ioutil.ReadAll(resp.Body)
	// fmt.Println(resp.Body)
	// fmt.Println(string(body))
	io.Copy(inputFile, resp.Body)
	outputFile, err := os.Create(fmt.Sprintf("../../TikTokVid/resVideo_%d.mp4", id))
	if err != nil {
		fmt.Println(err)
	}
	defer outputFile.Close()
	defer inputFile.Close()
	/////
	r := bufseekio.NewReadSeeker(inputFile, 128*1024, 4)
	w := mp4.NewWriter(outputFile)
	_, err = mp4.ReadBoxStructure(r, func(h *mp4.ReadHandle) (interface{}, error) {
		switch h.BoxInfo.Type {
		case mp4.BoxTypeEmsg():
			// write box size and box type
			_, err := w.StartBox(&h.BoxInfo)
			if err != nil {
				return nil, err
			}
			// read payload
			box, _, err := h.ReadPayload()
			if err != nil {
				return nil, err
			}
			// update MessageData
			emsg := box.(*mp4.Emsg)
			emsg.MessageData = []byte("hello world")
			// write box playload
			if _, err := mp4.Marshal(w, emsg, h.BoxInfo.Context); err != nil {
				return nil, err
			}
			// rewrite box size
			_, err = w.EndBox()
			return nil, err
		default:
			// copy all
			return nil, w.CopyBox(r, &h.BoxInfo)
		}
	})
	////
	return nil, err
}

func (c *Client) getListVideo() *UserPostVideoResponse {
	urlRapid := videoBaseURL + "?" + "unique_id=" + userID + "&count=1"
	request, err := http.NewRequest("GET", urlRapid, nil)
	if err != nil {
		fmt.Println("Can't create request")
	}
	result := &UserPostVideoResponse{}
	request.Header.Add("X-RapidAPI-Key", "b3470ef89emshccb2fbc24f3837bp108053jsn64a8bb6f104e")
	request.Header.Add("X-RapidAPI-Host", "tiktok-video-no-watermark2.p.rapidapi.com")

	fmt.Println("Request setup")
	fmt.Println(request)

	resp, err := c.httpClient.Do(request)

	if err != nil {
		fmt.Println(err)
	}

	defer resp.Body.Close()
	if resp.StatusCode != 200 {
		fmt.Println("Err get API")
		fmt.Println(resp.StatusCode)
	}
	body, err := ioutil.ReadAll(resp.Body)
	// fmt.Println("Resp body")
	// fmt.Println(string(body))
	if err != nil {
		fmt.Println("Can't unmarshal body")
	}

	err = json.Unmarshal(body, &result)
	if err != nil {
		fmt.Println("Cant unmarshal to res")
	}
	return result
}
