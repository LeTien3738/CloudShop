// Natural Snow Animation Script
function createSnow() {
    const snowContainer = document.createElement('div');
    snowContainer.className = 'snow-container';
    document.body.appendChild(snowContainer);

    // Tạo 60 bông tuyết với thuộc tính đa dạng
    for (let i = 0; i < 60; i++) {
        const snowflake = document.createElement('div');
        snowflake.className = 'snowflake';
        
        // Kích thước ngẫu nhiên
        const size = 4 + Math.random() * 8;
        snowflake.style.width = size + 'px';
        snowflake.style.height = size + 'px';
        snowflake.style.fontSize = size + 'px';
        
        // Vị trí bắt đầu ngẫu nhiên
        snowflake.style.left = Math.random() * 100 + '%';
        
        // Thời gian rơi ngẫu nhiên
        const fallDuration = 10 + Math.random() * 15;
        const swayDuration = 2 + Math.random() * 4;
        snowflake.style.animationDuration = `${fallDuration}s, ${swayDuration}s`;
        
        // Để tuyết xuất hiện ngay lập tức, một số bông tuyết bắt đầu ở giữa màn hình
        // Delay âm để animation đã chạy một phần
        const delay = -(Math.random() * fallDuration);
        snowflake.style.animationDelay = `${delay}s, ${Math.random() * swayDuration}s`;
        
        // Độ mờ ngẫu nhiên (tuyết xa mờ hơn)
        snowflake.style.opacity = 0.4 + Math.random() * 0.6;
        
        // Tốc độ xoay ngẫu nhiên
        const rotateSpeed = 0.5 + Math.random() * 1.5;
        snowflake.style.setProperty('--rotate-speed', rotateSpeed + 's');
        
        // Biên độ lắc lư ngẫu nhiên
        const swayAmount = 30 + Math.random() * 70;
        snowflake.style.setProperty('--sway-amount', swayAmount + 'px');
        
        snowContainer.appendChild(snowflake);
    }
}

// Khởi tạo khi trang load
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', createSnow);
} else {
    createSnow();
}
