using System.Collections.Generic;

namespace GoLani_ModPack
{
    // 전체 메타데이터 구조를 나타냅니다.
    public class Metadata
    {
        /// 모드 리스트
        public List<MetadataMod> Mods { get; set; }
    }
    // 개별 모드의 메타데이터 구조를 나타냅니다.
    
    public class MetadataMod
    {
        // 모드 이름 (예: "SAIN")
        public string Name { get; set; }
        // 모드 버전 (예: "3.2.0")
        public string Version { get; set; }
        // 다운로드 가능한 URL 리스트
        public List<string> DownloadUrls { get; set; }
        // 한글화 버전 여부
        public bool KrVersion { get; set; }
        // 출처 링크 URL
        public string SourceUrl { get; set; }
    }
}
