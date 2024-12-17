using System.Collections.Generic;

namespace GoLani_ModPack
{
    /// <summary>
    /// 전체 메타데이터 구조를 나타냅니다.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// 모드 리스트
        /// </summary>
        public List<MetadataMod> Mods { get; set; }
    }

    /// <summary>
    /// 개별 모드의 메타데이터 구조를 나타냅니다.
    /// </summary>
    public class MetadataMod
    {
        /// <summary>
        /// 모드 이름 (예: "SAIN")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 모드 버전 (예: "3.2.0")
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 다운로드 가능한 URL 리스트
        /// </summary>
        public List<string> DownloadUrls { get; set; }

        /// <summary>
        /// 한글화 버전 여부
        /// </summary>
        public bool KrVersion { get; set; }

        /// <summary>
        /// 출처 링크 URL
        /// </summary>
        public string SourceUrl { get; set; }
    }
}
